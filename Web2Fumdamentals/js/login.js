function loginProcess() {
  var userName = document.getElementById("txtUserName").value;
  var password = document.getElementById("txtPassword").value;
  if (userName == "admin" && password == "admin") {
    alert("login success");
    updateColor("");
  } else {
    alert("invalid user!");
    updateColor("red");
  }
}

function updateColor(colorCode) {
  document.getElementById("txtUserName").style.backgroundColor = colorCode;
  document.getElementById("txtPassword").style.backgroundColor = colorCode;
}
