function alertok($str){
	weui.toast($str);	
}

function alerterr($str){
	weui.topTips($str);	
} 

function reloadwin(){
	setTimeout(function(){location.reload()},500);	
}
