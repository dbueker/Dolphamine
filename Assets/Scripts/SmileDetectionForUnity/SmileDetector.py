import socket
import cv2

host, port = "127.0.0.1", 25001
sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
sock.connect((host, port))

face_detector = cv2.CascadeClassifier("haarcascade_frontalface_default.xml")
smile_detector = cv2.CascadeClassifier("haarcascade_smile.xml")
messung = "leer"

# Get Webcam
webcam = cv2.VideoCapture(0)

running = True


def sendData():
    # Converting string to Byte, and sending it to C#
    sock.sendall("smile".encode("UTF-8"))
    # receiveing data in Byte fron C#, and converting it to String
    receivedData = sock.recv(1024).decode("UTF-8")
    print(receivedData)


def checkGameOver():
    sock.sendall("GameOverCheck".encode("UTF-8"))
    receivedData = sock.recv(1024).decode("UTF-8")
    print(receivedData)
    if "GameOver" in receivedData:
        return False
    else:
        return True


while running:

    # Store the webcam's frame as frame & abort on error
    successful_frame_read, frame = webcam.read()
    if not successful_frame_read:
        break

    running = checkGameOver()
    print("Check was passed")
    if (checkGameOver() == False):
        break

    # Change frame to grayscale for optimization
    frame_grayscale = cv2.cvtColor(frame, cv2.COLOR_BGR2GRAY)

    # Detect faces
    faces = face_detector.detectMultiScale(frame_grayscale)

    # Draw Rectangle around faces
    for (x_face, y_face, w_face, h_face) in faces:
        cv2.rectangle(frame, (x_face, y_face), (x_face + w_face,
                                                y_face + h_face), (100, 200, 50), 4)

        # Get face_frame to only detect smiles inside faces
        face_frame = frame[y_face:y_face+h_face, x_face:x_face+w_face]

        # Change face_frame to grayscale for optimization
        face_frame_grayscale = cv2.cvtColor(face_frame, cv2.COLOR_BGR2GRAY)

        # Detect smiles in faces
        smiles = smile_detector.detectMultiScale(
            face_frame_grayscale, scaleFactor=1.7, minNeighbors=20)

        # Send Data if smile is detected. Also print values of detected_smile
        for (detected_smile) in smiles:
            print("smiled")
            sendData()

    # Delay loop for better performance
    cv2.waitKey(1)

webcam.release()
cv2.destroyAllWindows()
