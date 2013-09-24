function generateUniqueAccountName(prefix) {
var now = new Date()
var month = zeroPad(now.getMonth()+1); //getMonth returns 0..11 so must add 1
var date = zeroPad(now.getDate());
var hours = zeroPad(now.getHours());
var minutes = zeroPad(now.getMinutes());
var seconds = zeroPad(now.getSeconds());
var milliseconds = now.getMilliseconds();
return(prefix +
now.getFullYear() +
month +
date +
hours +
minutes +
seconds +
milliseconds);
}


function zeroPad(number) {
if (number < 10)
{number = "0" + number}
return String(number)
}