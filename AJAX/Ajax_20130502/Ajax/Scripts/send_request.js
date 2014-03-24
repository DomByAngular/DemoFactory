
function send_request(url) {
    //初始化、指定处理函数、发送请求的函数
    http_request = false;
    //开始初始化XMLHttpRequest对象
    if (window.XMLHttpRequest) { //Mozilla 浏览器
        http_request = new XMLHttpRequest();
        if (http_request.overrideMimeType) {//设置MiME类别
            http_request.overrideMimeType('text/xml');
        }
    }
    else if (window.ActiveXObject) { // IE浏览器
        try 
        {
            http_request = new ActiveXObject("Msxml2.XMLHTTP");
        }
        catch (e)
        {
                try 
                {
                    http_request = new ActiveXObject("Microsoft.XMLHTTP");
                }
                catch (e) {
                    alert("创建XMLhttp对象出现异常");
                }
        }
    }
    if (!http_request) { // 异常，创建对象实例失败
        window.alert("不能创建XMLHttpRequest对象实例.");
        return false;
    }
    //以下
    http_request.onreadystatechange = processRequest;
    // 确定发送请求的方式和URL以及是否同步执行下段代码
    http_request.open("GET", url, true);
    http_request.send(null);
}

// 处理返回信息的函数
function processRequest() {
    // 判断对象状态
    // readyState: 对象状态(integer):0 = 未初始化,1 = 读取中,2 = 已读取,3 = 交互中,4 = 完成
    if (http_request.readyState == 4) {
        // 信息已经成功返回，开始处理信息
        //status : 服务器返回的状态码, 如：404 = "文件末找到" 、200 ="成功"
        if (http_request.status == 200) {
            var temp = http_request.responseText;
            ControlResponseText(temp);
            //document.getElementById(currentPos).innerHTML = http_request.responseText;
        }
        else { //页面不正常
            alert("您所请求的页面有异常。");
        }
    }
}

//以下是对responseText的响应处理
function ControlResponseText(temp) {
    var arrs = temp.split("|");
    if (arrs[0] == "ok") {
        $("#ProductPrice").val(arrs[1]+"元");
    }
    else if (arrs[0] == "none") {
        alert("查无此这个商品");
        $("#ProductPrice").val("");
        $("#ProductName").val("");
    }
    else {
        alert("Ajax出现异常");
    }
}