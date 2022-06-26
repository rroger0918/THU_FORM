

  //(function () {
  //  // emailjs.init("USERID");
  //  emailjs.init("user_Ec3EGOLiAx79C0pwx9cEw");
  //})();

  ///**
  //  emailjs.send("SERVICE ID", "TEMPLATE NAME", {
  //    to_name: "USERNAME",
  //    from_name: "FROM NAME",
  //    message: "MESSAGE",
  //  });
  // **/

  //function validate() {
  //  let loader = document.querySelector(".loader");
  //  let name = document.querySelector(".user_name");
  //  let msg = document.querySelector(".message");
  //  let email = document.querySelector(".email");   
  //  let subject = document.querySelector(".subject");
  //  let btn = document.querySelector(".submit");
    

  //  btn.addEventListener("click", (e) => {
  //    e.preventDefault();
  //      if (name.value == "" || email.value == "" || msg.value == "" || subject.value == "") {
  //      emptyerror();
  //    } else {
  //        loader.style.display = "flex";
  //        sendmail(name.value, email.value, msg.value, subject.value);
  //      success();
  //      loader.style.display = "none";
  //    }
  //  });
  //}
  //validate();

  //function sendmail(name, email, msg, subject) {
  //  emailjs.send("service_38yxfmh", "template_ot6lgqg", {
  //    to_name: "TopMonManager",
  //    name : name,
  //    from_name: email,
  //    subject:subject,
  //    message: msg,
  //  });
  //}

  //function emptyerror() {
  //  swal.fire({
  //    icon: "Error ! ",
  //    title: "Oops...",
  //    text: "The message cannot be blank ~",
  //  });
  //}

  //function error() {
  //  swal.fire({
  //    icon: "Error !",
  //    title: "Oops...",
  //    text: "Something is wrong....Please send me a letter : leekuantean@gmail.com ,THX!",
  //  });
  //}

  //function success() {
  //  swal.fire({
  //    icon: "success",
  //    title: "Successfully sent <3",
  //    text: "I will reply you as soon as possible ~ <3",
  //  });
  //}
