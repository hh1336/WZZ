class Common {
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
        return year + "年" + month + "月" + day + "日 " + h + ":" + mm + ":" + s;
    }
}