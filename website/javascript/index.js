function validate(){
  var reg = /^([A-Za-z0-9_\-\.])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,4})$/;

  if(reg.test(e.value)==false)
  {
    alert('Invalid Email Address');
    event.preventDefault();
    return false;
  }
  return true;
}
