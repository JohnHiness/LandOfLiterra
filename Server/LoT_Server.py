__author__ = 'John Hiness'
import socket
import thread
import time
import sys
import string


dev = True

host = ''
port = 3202
maximumConnections = 128
currentConnections = 0
# ss = socket.socket( socket.AF_INET, socket.SOCK_STREAM )

def printTime():
	while True:
		print time.time()
		time.sleep(5)


def cnslprint(text):
	print '[' + time.strftime('%H:%M:%S') + '] ' + text


def startListen():
	"""
	try:
		s = socket.socket( socket.AF_INET, socket.SOCK_STREAM )
	except socket.error, msg:
		cnslprint('Failed to create socket. Error code: ' + str(msg[0]) + ' , Error message : ' + msg[1])
		sys.exit()
	cnslprint("Socket created.") """
	try:
		s.bind((host, port))
	except socket.error , msg:
		cnslprint('Bind failed. Error code: ' + str(msg[0]) + ' Message ' + msg[1])
		sys.exit()
	cnslprint("Socket bind successful on port " + str(port))
	s.listen(10)


try:
	s = socket.socket( socket.AF_INET, socket.SOCK_STREAM )
except socket.error, msg:
	cnslprint('Failed to create socket. Error code: ' + str(msg[0]) + ' , Error message : ' + msg[1])
	sys.exit()
cnslprint("Socket created.")


def clientThread(client, name):
	def send(text):
		if dev:
			cnslprint(" >> " + name + ' :' + text)
		client.send(text + '\n')
	send("conRes|ok")
	readbuffer = ''
	while True:
		try:
			readbuffer = readbuffer + client.recv(2048)
		except BaseException as err:
			cnslprint("Error recieving from " + name + ' : ' + str(err))
			break
		temp = string.split(readbuffer, "\n")
		readbuffer = temp.pop()
		for rline in temp:
			rline = string.rstrip(rline)
			rline = string.split(rline)
			if dev:
				cnslprint("<<  " + name + ' :' + ' '.join(rline))
	cnslprint("Closing connection with " + name)
	client.close()


if __name__ == '__main__':
	startListen()
	#thread.start_new_thread(printTime, ())
	while True:
		conn, addr = s.accept()
		cnslprint("Connected with " + addr[0] + ':' + str(addr[1]))
		clName = addr[0] + ':' + str(addr[1])
		thread.start_new_thread(clientThread, (conn, clName))
	s.close()