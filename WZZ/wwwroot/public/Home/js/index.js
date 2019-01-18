$(function() {
  var sWidth = $(".item").width(); //获取焦点图的宽度（显示面积）
  var len = $(".item ul li").length; //获取焦点图个数
  var index = 0;
  var picTimer;
  var tit;
  //文章标题
  
  //以下代码添加数字按钮和按钮后的半透明条，还有上一页、下一页两个按钮
  var btn = "<div class='btnBg'></div><div class='btn'>";
  for(var i=0; i < len; i++) {
	  btn += "<span></span>";
	  
	 
  }
  btn += "</div><div class='preNext pre'></div><div class='preNext next'></div>";
  $(".item").append(btn);
  $(".item .btnBg").css("opacity",0.5);

  //为小按钮添加鼠标滑入事件，以显示相应的内容
  $(".item .btn span").css("opacity",0.4).mouseover(function() {
	  index = $(".item .btn span").index(this);
	  showPics(index);
  }).eq(0).trigger("mouseover");

  //上一页、下一页按钮透明度处理
  $(".item .preNext").css("opacity",0.2).hover(function() {
	  $(this).stop(true,false).animate({"opacity":"0.5"},300);
  },function() {
	  $(this).stop(true,false).animate({"opacity":"0.2"},300);
  });

  //上一页按钮
  $(".item .pre").click(function() {
	  index -= 1;
	  if(index == -1) {index = len - 1;}
	  showPics(index);
  });

  //下一页按钮
  $(".item .next").click(function() {
	  index += 1;
	  if(index == len) {index = 0;}
	  showPics(index);
  });

  //图片为左右滚动，即所有li元素都是在同一排向左浮动，所以这里需要计算出外围ul元素的宽度
  $(".item ul").css("width",sWidth * (len));
  
  //鼠标滑上焦点图时停止自动播放，滑出时开始自动播放
  $(".item").hover(function() {
	  clearInterval(picTimer);
  },function() {
	  picTimer = setInterval(function() {
		  showPics(index);
		  index++;
		  if(index == len) {index = 0;}
	　　  },4000); //此4000代表自动播放的间隔，单位：毫秒
  }).trigger("mouseleave");
  
  //显示图片函数，根据接收的index值显示相应的内容
  function showPics(index) { //普通切换
	var nowLeft = -index*sWidth; //根据index值计算ul元素的left值
	//使用animate()方法调整ul元素滚动到计算出的position
	$(".item ul").stop(true,false).animate({"left":nowLeft},300); 
	//为当前的按钮切换到选中的效果
	$(".item .btn span").stop(true,false).animate({"opacity":"0.4"},300)
	　.eq(index).stop(true,false).animate({"opacity":"1"},300); 
    }

    //返回顶部
    $(function gotoTOP() {

        $('#goToTop').hide();        //隐藏go to top按钮

        $(window).scroll(function () {
            // console.log($(this).scrollTop());

            //当window的scrolltop距离大于1时，go to
            if ($(this).scrollTop() > 100) {
                $('#goToTop').fadeIn();
            } else {
                $('#goToTop').fadeOut();
            }
        });

        $('#goToTop a').click(function () {
            $('html ,body').animate({ scrollTop: 0 }, 300);
            return false;
        });


    });
});