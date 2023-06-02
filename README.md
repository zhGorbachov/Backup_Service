# Backup_Service

<h2>Information about it</h2>

This site, roughly speaking, is designed to archive your file:
<br> has n-layer architecture;
<br> prescribed repositories and services to each table;
<br> then all the features are available to you, so far from them are:
- archiving all types of files, multi-selection for files is possible, but there is a minus, it is not possible to upload folders.
- registration to the account, which then will be entered in the mysql database.
- login to the existing account.<br>

<h3>To use this code you need:</h3>
- Nuget packages installed.<br>
- A nuget package DotNetZip installed, with which you can use the functions of the archiver. 

<h2>Small tutorial of web site</h2>

<h3>When you go to this site you go to the home page, after which you have a choice:</h3>

![image](https://github.com/zhGorbachov/Backup_Service/assets/115892673/7ce10623-1659-4433-8245-702bfa31be8e)


<br>1) First is registration form, for it you need to put on "Registration" button top right, after it you have a form where you need to fill in your nickname, password and confirm it to create an account;
<h5>After that you can move on to other functionality</h5>

![image](https://github.com/zhGorbachov/Backup_Service/assets/115892673/5b99e25f-e1c7-4ef0-b5ea-e7707e98add2)

<br>2) Second one it is login page, button of login is located at "Registration" button and called "Login", after redirecting to another page, you need to sign in on existing account, that need to work for main program;
<h5>Just put there your data of account, and press on button.</h5>

![image](https://github.com/zhGorbachov/Backup_Service/assets/115892673/e39b7c08-a840-41e8-8528-9ad8f29195e1)

<h6>When you logined in account, you will see another button instead of previous buttons, it is "Exit" button, that would come out of your account.</h6>

![image](https://github.com/zhGorbachov/Backup_Service/assets/115892673/507ec0ab-8b50-422f-9207-b6640186ac49)


<br>3) And the last one is the most important in this web site, is archivate app, to start working with it you need to be logined in account, and press the button "Start" on Home page.

![image](https://github.com/zhGorbachov/Backup_Service/assets/115892673/df153f3a-b217-4337-bd50-115b7ab6a9fd)

<h5>A little note, if you want to click on this button when you log into your account, you will get an error and it will return your registration page</h5>

![image](https://github.com/zhGorbachov/Backup_Service/assets/115892673/f581dbe9-b2be-4b7c-964e-a1722b9c787d)


<h4>Further actions will be divided into two subparagraphs:</h4><br>
- First one is Uploading page, which will take your files and will uploading them.
<h5>If you want to start without loading files, you will take an error and you will be redirected to home page.

![image](https://github.com/zhGorbachov/Backup_Service/assets/115892673/1da16df5-4c5d-405e-a9ec-776e30dae98a)

- And last one is Downloading page, which will give .zip file for you, which will have your files.

![image](https://github.com/zhGorbachov/Backup_Service/assets/115892673/e669aa52-1d7d-4ab9-b56d-635e96256d9d)
  
You will download your file, and have fun.

