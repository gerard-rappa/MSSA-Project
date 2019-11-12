# Meme-Me

[Check out the prototype!](https://meme-me.azurewebsites.net/)

This repository showcases all the functionality which utilizes Azure for blob storage for all of the files, as well as the databases which store the paths for all of the images in addition to their latitude and longitude, and another for user/password information for admins. 

This is the start of a web app where anyone can upload memes to a site, essentially anonymously, and it can be filtered by only those posted nearby.
Currently, if a user does not consent to sharing their location, the default location is in the middle of the Bermuda triangle.


## Index
1. [Home View](#home-view)
1. [Local Modal](#local-modal)
1. [Add Modal](#add-modal)
1. [Admin Page](#admin-page)
1. [Map View](#map-view)
1. [Database Stuff](#database-stuff)
1. [Requirements Traceability](#requirements-traceability)


## [⮤](#index)Home View
This is how the users are greeted

![GitHub Logo](/gitImages/Home.JPG)

## [⮤](#index)Local Modal
This pops up when a user wants to view memes posted in their area. The stone's throw is my favorite unit of measurement, so my classmate, Carson, and I calculated how far a stone's throw actually is. I modified the orthodromic distance formula a bit in order to handle that unit of measurement, as well as provide me with values I could use to quickly retrieve data from a database. 

![GitHub Logo](/gitImages/LocalModal.JPG)

## [⮤](#index)Add Modal
This pops up when a user wants to upload a meme, and dissapears if they click anywhere outside of the box 

![GitHub Logo](/gitImages/AddModal.JPG)

## [⮤](#index)Admin Page
I wanted some administrative rights in app so I could delete unwanted content anywhere that has internet. I didnt want everyone to have access, so I added some authentication to get there.

![GitHub Logo](/gitImages/AdminLogin.png)

Here you can see that I can delete unwanted content, as well as add content that sticks to the top

![GitHub Logo](/gitImages/AdminDelete.png)
![GitHub Logo](/gitImages/AdminSticky.png)

## [⮤](#index)Map View
I also wanted some map functionality. Right now you can see where people are posting memes from, and the images for the clusters of markers gets spicier as more and more people post memes in the same area. When you click on a cluster while zoomed out, the map will zoom in. If you click on a cluster while zoomed in all the way, an option appears where you can see all of the memes posted there!

![GitHub Logo](/gitImages/MapButton.png)
![GitHub Logo](/gitImages/Cluster.JPG)
![GitHub Logo](/gitImages/ClusterOnClick.JPG)

## [⮤](#index)Database Stuff
This is the current state of my database. Simple. Elegant. I also have a database for users, but as of now, I am the only user, and its for the purpose of moderating content and posting sticky information. I may implement functionality for a wider user base in the future. 

![GitHub Logo](/gitImages/Database.JPG)

## [⮤](#index)Requirements Traceability
This is a list of the tests that have been done, their status, and how/when they were last done.(https://github.com/atmarnat/TextForum/blob/master/TwaddleCate/README.md)

| TestNo.      | Status     | Build     | TimeStamp | Requirement       | Test Description | Test Method | Test Procedure |
| -----------: | :--------: | :-------: | :-------: | :---------------: | :--------------- | :---------: | :------------: |
| 1            | Passed     | 1.0       | 11/3/2019 | Navbar Functionality| Home button redirects user to top of home page | Demonstration | Click leftmost link on navbar |
| 1.1          | Passed     | 1.0       | 11/3/2019 |                   | If screen is below a certain width, hide menu options in expandable list | Demonstration | Resize browser window |
| 1.2          | Passed     | 1.0       | 11/3/2019 |                   | Local Memes and Add buttons upen modal windows | Demonstration | Click Local Memes and Add buttons |
| 1.4          | Passed     | 1.0       | 11/3/2019 |                   | Buttons redirect to correct pages with correct parameters | Demonstration | Click buttons |
| 2            | Passed     | 1.0       | 11/3/2019 | Location Information  | Check if user location is being shared | Demonstration | Click Local Memes and see if url shows correct information |
| 2.1          | Passed     | 1.0       | 11/3/2019 |                   |  Default location set to Bermuda Triangle | Demonstration | Block location and click Local Memes to see if url shows correct information |
| 2.2          | Passed |   1.0     |           |                   | Obscure coordinates when displayed on site | Demonstration | Upload meme and compare displayed coordinates to coordinates in url |
| 3            | Passed     | 1.0       | 11/3/2019 | Image Uploads  | Do not allow anything that is over 10MB or not a gif, jpg, png, or webm | Demonstration  | Attempt to upload incompatible file |
| 3.1          | Passed     | 1.0       | 11/3/2019 |                   | Attach Lat and Lon coordinates to photo | Demonstration | Upload meme and check coordinates on site |
| 3.2          | Not Tested     | 1.0       | 11/3/2019 |                   | Client Side Validation | Inspection | Attempt to upload incompatible file |
| 3.3          | Passed |    1.0       |           |                   | Set max dimensions for memes | Demonstration | Resize window |
| 4            | Passed     | 1.0       | 11/3/2019 | Map Functionality    | See that memes cluster appropriately | Demonstration | View map and see that meme cluster radius shrinks at certain zooms |
| 4.1          | Passed     | 1.0       | 11/3/2019 |                   | See that clusters zoom in when not at max zoom  | Demonstration | Click clusters while zoomed out |
| 4.2          | Passed     | 1.0       | 11/3/2019 |                   | Clicking cluster while zoomed in redirects you to local memes in that area | Demonstration | Click links to see if they show memes in that area |
| 4.3          | Passed     | 1.0       | 11/3/2019 |                   | Highlight Bermuda Triangle | Demonstration | View the page and see if Bermuda Triangle is highlighted |
| 4.4          | Passed     | 1.0       | 11/3/2019 |                   | See that spiciness of clusters increases as more memes get added | Demonstration  | Add multiple memes to same area |
| 5.0        |       |       |  |    User Reported Bugs      |  |  | |
| 5.1          | Passed     | 1.0       | 11/3/2019 |                   | Modals not showing and buttons not working on older iPhones | Demonstration  | Test on iOS devices |
| 5.2         | Not Tested     | 1.0       | 11/3/2019 |                   | Website flooded with absurd amounts of location requesting pop ups on facebook browser  | Inspection  | Test in facebook browser |
| 5.3          | Not Tested     | 1.0       | 11/3/2019 |                   | Photos uploadaed sideways when sent directly from camera | Inspection  | Upload images directly from camera |
