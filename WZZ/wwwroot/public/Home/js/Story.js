$(document).ready(function(){
	//弹窗
   var height = document.body.clientHeight; 
      $("#modal").height(height) ;
      var width = document.body.clientWidth; 
      $("#modal").width(width) ;
    $("#text").click(function (){
    	$("#modal").slideToggle();
    	
    });
    $(".close").click(function(){
    	$("#modal").slideToggle();
    });
    //导航变小
    	  $(".img").click(function(){
               	  	$(".navlist1").slideToggle(1000)
               	  });
    
}); 
	