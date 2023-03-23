from os import listdir
from os.path import isfile, join
import requests
import socket

MYPATH = "c:/temp"
myip = "10.200.179.114"
MYPORT = 7000
onlyfiles = [f for f in listdir(MYPATH) if isfile(join(MYPATH, f))]

api_url = "http://localhost:5126/api/Files"
for filename in onlyfiles:
    myobject = {"IpAddress": myip, "port": MYPORT}
    response = requests.post(api_url + "/" + filename, json=myobject)
    print(response)
    print(response.json())

s = socket.socket()
s.bind(('', MYPORT))
s.listen(5)
while True:
    connectionSocket, addr = s.accept()

    print('Got connection from ', addr)
    fileName = connectionSocket.recv(1024).decode()
    print("Opening file...", fileName)
    file = open('C:/temp/' + fileName, 'rb')
    file_data = file.read(1024)
    while (file_data):
        print('sending...')
        connectionSocket.send(file_data)
        file_data = file.read(1024)
    file.close()
    print("done sending")
    connectionSocket.shutdown(socket.SHUT_WR)
