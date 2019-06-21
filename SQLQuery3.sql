update Rooms set[ImageData]=(select MyImage.* 
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\А1.jpg', Single_Blob) MyImage)
where RoomId=1

update Rooms set[ImageData]=(select MyImage.*
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\А2.jpg', Single_Blob) MyImage)
where RoomId=2

update Rooms set[ImageData]=(select MyImage.*
from Openrowset(Bulk 'E:\EPAM\MyHotel — копия — копия\Hotel.WebUI\Content\Images\А3.jpg', Single_Blob) MyImage)
where RoomId=3
