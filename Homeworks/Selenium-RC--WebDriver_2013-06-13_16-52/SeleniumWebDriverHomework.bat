set _my_datetime=%date%_%time%
set _my_datetime=%_my_datetime: =_%
set _my_datetime=%_my_datetime::=%
set _my_datetime=%_my_datetime:/=_%
set _my_datetime=%_my_datetime:.=_%

SET SERVER="C:\Users\Angel\Desktop\QA Academy\QA Part - I\Others\SeleniumWebDriverExercise\SeleniumWebDriverExercise\selenium-server-standalone-2.33.0.jar"
SET EXTENSIONS=-userExtensions "C:\Users\Angel\Desktop\QA Academy\QA Part - I\Others\SeleniumWebDriverExercise\SeleniumWebDriverExercise\user-extensions.js"
SET PROFILE=-firefoxProfileTemplate "C:\Users\Angel\Desktop\FireFoxTestProfiles"
SET BROWSER=-htmlsuite *firefox
SET BASE_URL=http://test.telerikacademy.com/SoftwareAcademy/Candidate
SET TEST_SUIT="C:\Users\Angel\Desktop\QA Academy\QA Part - I\Homework\07_Selenium WebDriver\SeleniumWebDriverHomeworkTestSuit.html"
SET RESULT=C:\Users\Angel\Desktop\Result_%_my_datetime%.html


START java -jar %SERVER% %EXTENSIONS% %PROFILE% %BROWSER% %BASE_URL% %TEST_SUIT% %RESULT% 
