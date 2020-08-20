
String apiURL = "http://192.168.1.24:5000/api";
String apiURLlocalhost = "http://localhost:8000/api";

String apiUsers = "$apiURL/users";

String apiAuthenticate = "$apiURL/users/authenticate";

String apiCourse = "$apiURL/course";

Map<String,String> headers = {
  "Accept": "application/json",
  "content-type": "application/json"
};