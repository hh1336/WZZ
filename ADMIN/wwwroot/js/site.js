﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

class Common {
    //根据key获取Session值
    static GetSession(key, callback) {
        $.ajax({
            url: "/Home/GetSessionValue",
            type: "post",
            dataType: "json",
            data: { key: key },
            async: false
        }).done((value) => {
            callback(value);
        });
    }
    //设置session的值
    static SetSession(key, val) {
        $.post("/Home/SetSession", { key: key, value: val });
    }

    //转换时间
    static ToDateTime(time) {
        var d = new Date(time);
        var year = d.getFullYear();
        var month = d.getMonth();
        month++;
        var day = d.getDate();
        month = month < 10 ? "0" + month : month;
        day = day < 10 ? "0" + day : day;
        var h = d.getHours();
        var mm = d.getMinutes();
        var s = d.getSeconds();
        return year + "年" + month + "月" + day + "日 " + h + ":" + mm + ":" + s ;
    }

    //自定义弹框（回调函数如果带有参数，则只能传入匿名函数）
    static alert(title, msg, yescallback, endcallback) {
        //当没有传入回调函数时
        if (yescallback === undefined && endcallback === undefined) {
            layer.open({
                title: title,
                content: msg,
                btn: ["确定", "取消"],
                btn1: () => { return 1; },
                btn2: () => { return 0; }
            });
            return;
        }
        //当传入一个回调函数时
        if (yescallback !== undefined && endcallback === undefined) {
            layer.open({
                title: title,
                content: msg,
                btn: ["确定", "取消"],
                btn1: yescallback,
                btn2: () => { return 0; }
            });
            return;
        }
        layer.open({
            title: title,
            content: msg,
            btn: ["确定", "取消"],
            btn1: yescallback,
            btn2: endcallback
        });
    }

}


//封装模态框
var appModal = (obj) => {//初始获取模态框
    this.model = $("#myModal");
    this.mtitle = $("#myModalLabel");
    this.mbody = $(".modal-body");
    this.clear();

    //实例化时需要传入参数将模态框进行初始化
    if (obj !== undefined) this.init(obj);

};

appModal.prototype = {
    //弹出模态框
    open: () => {
        this.model.modal("show");
    },
    //关闭模态框
    close: () => {
        this.model.modal("hiden");
    },
    init: (obj) => {
        //模态框的标题
        this.mtitle.text(obj.title);
        //发送一个ajax请求，将子页面渲染到模态框中
        if (obj.url !== undefined) {
            $.ajax({
                url: obj.url,
                dataType: "html",
                type: "post",
                data: obj.data === undefined ? {} : obj.data,
                async: false
            }).done((result) => {
                this.mbody.html(result);
            });
        }
        if (obj.body !== undefined) {
            this.mbody.html(obj.body);
        }

    },
    //清空模态框内容
    clear: () => {
        this.mtitle.text("标题");
        this.mbody.html("");
    }
};

