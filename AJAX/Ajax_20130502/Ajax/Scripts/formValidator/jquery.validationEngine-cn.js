(function($) {
    $.fn.validationEngineLanguage = function() {
    };
    $.validationEngineLanguage = {
        newLang: function() {
            $.validationEngineLanguage.allRules = {
                "required": { // Add your regex rules here, you can take telephone as an example
                    "regex": "* 必填项",
                    "alertText": "* 请填写",
                    "alertTextCheckboxMultiple": "* 请选择",
                    "alertTextCheckboxe": "* 必须勾选",
                    "alertTextSelectQuestion": "* 请选择问题",
                    "alertTextSelectProvince": "* 请选择省份"
                },
                "minSize": {
                    "regex": "* 必填项",
                    "alertText": "* 不能少于",
                    "alertText2": "位数"
                },
                "maxlength": {
                    "regex": "* 必填项",
                    "alertText": "* 不能超过",
                    "alertText2": "个字符"
                },
                "min": {
                    "regex": "* 必填项",
                    "alertText": "* 不能小于"
                },
                "max": {
                    "regex": "* 必填项",
                    "alertText": "* 不能大于"
                },
            
                "past": {
                    "regex": "* 必填项",
                    "alertText": "* 日期格式为 "
                },
                "future": {
                    "regex": "* 必填项",
                    "alertText": "* 时间要大于"
                },
                "maxCheckbox": {
                    "regex": "* 必须勾选",
                    "alertText": "* 超过允许勾选数"
                },
                "minCheckbox": {
                    "regex": "* 必须勾选",
                    "alertText": "* 至少勾选",
                    "alertText2": "项"
                },
                "equals": {
                    "regex": "* 必填项",
                    "alertText": "* 输入值不相同"
                },

                "age": {
                // credit: jquery.h5validate.js / orefalo
               // "regex": /^[0-149]$/,

                "regex": /(^[1-9]\d$)|(^\d$)|(^100$)/,
     

                    "alertText": "* 年龄不对"
                },
                
                "phone1": {
                    // credit: jquery.h5validate.js / orefalo
                    "regex": /^(0[0-9]{3}\-)?([2-9][0-9]{7})?$/,
                    "alertText": "* 无效的电话号码"
                },
                "phone": {
                    // credit: jquery.h5validate.js / orefalo
                    "regex": /^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$/,
                    "alertText": "* 无效的电话号码"
                },
                "mobilephone": {
                    "regex": /(^0?[1][358][0-9]{9}$)/,
                    "alertText": "* 请输入有效的手机号码."
                },
                "qq": {
                    "regex": /^[1-9]\d{4,9}$/,
                    "alertText": "* 请输入有效的QQ号码."
                },
                "email": {
                    // Simplified, was not working in the Iphone browser
                    "regex": /^([A-Za-z0-9_\-\.\'])+\@([A-Za-z0-9_\-\.])+\.([A-Za-z]{2,6})$/,
                    "alertText": "* 无效的Email地址"
                },
                "integer": {
                    "regex": /^[\-\+]?\d+$/,
                    "alertText": "* 只能为整数"
                },
                "number": {
                    // Number, including positive, negative, and floating decimal. credit: orefalo
                    "regex": /^[\-\+]?(([0-9]+)([\.,]([0-9]+))?|([\.,]([0-9]+))?)$/,
                    "alertText": "* 数字格式不正确"
                },
                "date": {
                    "regex": /^\d{4}[\/\-](0?[1-9]|1[012])[\/\-](0?[1-9]|[12][0-9]|3[01])$/,
                    "alertText": "* 无效的日期"
                },
                "ipv4": {
                    "regex": /^((([01]?[0-9]{1,2})|(2[0-4][0-9])|(25[0-5]))[.]){3}(([0-1]?[0-9]{1,2})|(2[0-4][0-9])|(25[0-5]))$/,
                    "alertText": "* 无效的IP地址"
                },
                "url": {
                    "regex": /^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/,
                    "alertText": "* 无效的URL地址"
                },
                "onlyNumberSp": {
                    "regex": /^[0-9\ ]+$/,
                    "alertText": "* 只能为整数"
                },
                "onlyLetterSp": {
                    "regex": /^[a-zA-Z\ \']+$/,
                    "alertText": "* 只能为字母"
                },
                "onlyLetterNumber": {
                    "regex": /^[0-9a-zA-Z]+$/,
                    "alertText": "* 只能数字、字母"
                },
                "QqNum": {
                    "regex": /(^\d{5,12}$)/,
                    "alertText": "* QQ号格式不正确"
                },
                "IdNum": {
                    "regex": /(^\d{15}$)|(^\d{17}([0-9]|[X|x])$)/,
                    "alertText": "* 无效的身份证号"
                },
                "uname": {
                // "regex": /^[0-9a-zA-Z_]+$/,
                "regex": /^[0-9a-zA-Z_]{4,16}$/,
           
               
                    "alertText": "*  格式不正确"
                },
                "pword": {
                    "regex": /^[^\s]+$/,
                    "alertText": "* 请不要输入空格."
                },
                // --- CUSTOM RULES -- Those are specific to the demos, they can be removed or changed to your likings
                "ajaxUserCall": {
                    "url": "ajaxValidateFieldUser",
                    // you may want to pass extra data on the ajax call
                    "extraData": "name=eric",
                    "alertText": "已存在",
                    "alertTextLoad": "验证中，请稍等..."
                },
                "ajaxUserCallPhp": {
                    "url": "phpajax/ajaxValidateFieldUser.php",
                    // you may want to pass extra data on the ajax call
                    "extraData": "name=eric",
                    // if you provide an "alertTextOk", it will show as a green prompt when the field validates
                    "alertTextOk": "可以使用",
                    "alertText": "已存在",
                    "alertTextLoad": "验证中，请稍等..."
                },
                "ajaxNameCall": {
                    // remote json service location
                    "url": "ajaxValidateFieldName",
                    // error
                    "alertText": "已存在",
                    // if you provide an "alertTextOk", it will show as a green prompt when the field validates
                    "alertTextOk": "可以使用",
                    // speaks by itself
                    "alertTextLoad": "验证中，请稍等..."
                },
                "ajaxNameCallPhp": {
                    // remote json service location
                    "url": "phpajax/ajaxValidateFieldName.php",
                    // error
                    "alertText": "已存在",
                    // speaks by itself
                    "alertTextLoad": "验证中，请稍等..."
                },
                "validate2fields": {
                    "alertText": "请输入123"
                }
            };

        }
    };
    $.validationEngineLanguage.newLang();
})(jQuery);