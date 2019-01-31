// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
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
        }).done(function (value) {
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

        return year + "年" + month + "月" + day + "日";
    }

    //自定义弹窗，有确定和取消按钮
    static alert(title, msg) {
        layer.open({
            title: title,
            btn: ["确定", "取消"],
            content: msg,
            yes: function () {
                return 1;
            },
            end: function () {
                return 0;
            }
        });
    }
    //重载弹窗
    static alert(title, msg, yescallback) {
        layer.open({
            title: title,
            btn: ["确定", "取消"],
            content: msg,
            yes: yescallback,
            end: function () {
                return 0;
            }
        });
    }
    //重载弹窗
    static alert(title, msg, yescallback, endcallback) {
        layer.open({
            title: title,
            btn: ["确定", "取消"],
            content: msg,
            yes: yescallback,
            end: endcallback
        });
    }

}


//封装模态框
var appModal = function () {//初始获取模态框
    this.model = $("#myModal");
    this.mtitle = $("#myModalLabel");
    this.mbody = $(".modal-body");
};

appModal.prototype = {
    //弹出模态框
    show: function () {
        this.model.modal("show");
    },
    //关闭模态框
    close: function () {
        this.model.modal("hiden");
    },
    init: function (obj) {
        this.mtitle.text(obj.title);
        $.ajax({
            url: obj.url,
            dataType: obj.dataType,
            type: "post",
            data: obj.data,
            async: false
        }).done(function (result) {
            
        });
    }
};

