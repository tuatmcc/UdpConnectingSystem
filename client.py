import socket
import time


class UDPClient:
    def __init__(self, host: str, port: int):
        self.address = (host, port)
        self.sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

    def __del__(self):
        self.sock.close()

    def send(self, packet: bytes) -> bool:
        try:
            result = self.sock.sendto(packet, self.address)
            return result
        except Exception as e:
            print(e)
            return False

client = UDPClient("192.168.0.254", 8080)
while True:
    try:
        #text = input(">").encode("utf-8")
        text = b"TEST"
        client.send(text)
    except KeyboardInterrupt:
        client.send(b"exit")
        break
    time.sleep(1)
