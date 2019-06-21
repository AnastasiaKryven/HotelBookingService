update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\Б1.jpg', Single_Blob) MyImage)
where RoomId=4

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\Б2.jpg', Single_Blob) MyImage)
where RoomId=5

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\Б3.jpg', Single_Blob) MyImage)
where RoomId=6

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\В1.jpg', Single_Blob) MyImage)
where RoomId=7

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\В2.jpg', Single_Blob) MyImage)
where RoomId=8

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\В3.jpeg', Single_Blob) MyImage)
where RoomId=9

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\Люкс1.jpg', Single_Blob) MyImage)
where RoomId=10

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\Люкс2.jpg', Single_Blob) MyImage)
where RoomId=11

update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\Люкс3.jpg', Single_Blob) MyImage)
where RoomId=12


