
import time

while 1 == 1:
   message = input("Lütfen Yazılmasını İstediğiniz Mesajı Giriniz :")
   for i in message:
      print(i)
      time.sleep(0.3)
      if message == "iptal":
         break

#Yapamadığım şey çıktı verilirken yazıyı tek satırda yazdırmaktı!!!

