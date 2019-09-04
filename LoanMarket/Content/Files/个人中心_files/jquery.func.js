function alertok($str){
	mui.toast($str);	
}

function alerterr($str){
	mui.toast($str);	
}

function reloadwin(){
	setTimeout(function(){location.reload()},500);	
}

var refreshAuthCode = function() {
    var n = APP_PATH+"/Index/verify?" + Math.random(); 
    $("img#authCode").attr("src", n)
};

//订单提交页-验证手机号
function is_mobile(mobile) {  
    if( mobile == "") {  
      	return false;  
    } else { 
        if( ! /^0{0,1}(13[0-9]|15[0-9]|17[0-9]|18[0-9]|14[0-9])[0-9]{8}$/.test(mobile) ) {  
        	return false;  
      	}  
      	return true;  
    }  
}  

//订单提交页-验证email的合法性  
function is_email(email) {  
    if ( email == "") {  
        return false;  
    } else {  
        if (! /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/.test(email)) {  
            return false;  
        }
    }  
    return true;
}  
