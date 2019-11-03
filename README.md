# Meme-Me
[Check out the prototype!](https://meme-me.azurewebsites.net/)

This repository showcases all the functionality which utilizes Azure for blob storage for all of the files, as well as the databases which store the paths for all of the images in addition to their latitude and longitude, and another for user/password information for admins. 

This is the start of a web app where anyone can upload memes to a site, essentially anonymously, and it can be filtered by only those posted nearby.
Currently, if a user does not consent to sharing their location, the default location is in the middle of the Bermuda triangle.

## Home View
This is how the users are greeted

![GitHub Logo](/gitImages/Home.JPG)

## Local Modal
This pops up when a user wants to view memes posted in their area. The stone's throw is my favorite unit of measurement, so my classmate, Carson, and I calculated how far a stone's throw actually is. I modified the orthodromic distance formula a bit in order to handle that unit of measurement, as well as provide me with values I could use to quickly retrieve data from a database. 

![GitHub Logo](/gitImages/LocalModal.JPG)

## Add Modal
This pops up when a user wants to upload a meme, and dissapears if they click anywhere outside of the box 

![GitHub Logo](/gitImages/AddModal.JPG)

## Admin Page
I wanted some administrative rights in app so I could delete unwanted content anywhere that has internet. I didnt want everyone to have access, so I added some authentication to get there.

![GitHub Logo](/gitImages/AdminLogin.png)

Here you can see that I can delete unwanted content, as well as add content that sticks to the top

![GitHub Logo](/gitImages/AdminDelete.png)
![GitHub Logo](/gitImages/AdminSticky.png)

## Map View
I also wanted some map functionality. Right now you can see where people are posting memes from, and the images for the clusters of markers gets spicier as more and more people post memes in the same area. When you click on a cluster while zoomed out, the map will zoom in. If you click on a cluster while zoomed in all the way, an option appears where you can see all of the memes posted there!

![GitHub Logo](/gitImages/MapButton.png)
![GitHub Logo](/gitImages/Cluster.JPG)
![GitHub Logo](/gitImages/ClusterOnClick.JPG)

## Database Stuff
This is the current state of my database. Simple. Elegant.

![GitHub Logo](/gitImages/Database.JPG)
