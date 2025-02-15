function sendMessage() {
  var userName = document.getElementById("txtName").value;
  var message = document.getElementById("txtMessage").value;
  if (userName === "") {
    document.getElementById("txtName").style.backgroundColor = "red";
    return;
  }
  alert(`Hello,${userName},Thanks for your message`);
}
