from socket import *

serverName = "localhost" # server name
serverPort = 7 

clientSocket = socket(AF_INET, SOCK_STREAM)
clientSocket.connect((serverName, serverPort))

while True:
    command = input("Enter command: ")  # Get user input
  

    clientSocket.sendall((command + "\n").encode())  # Send command to server
    if command == "close":  # Close connection if user enters "close"
        break
    result = clientSocket.recv(1024).decode()  # Receive server response
    print("Server response:", result) # Print server response

clientSocket.close()
