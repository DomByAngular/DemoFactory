/* Nano Templates (Tomasz Mazur, Jacek Becela) */
/* @see https://github.com/trix/nano */
(function ($) {
    $.nano = function (template, data) {
        return template.replace(/\{([\w\.]*)\}/g, function (str, key) {
            var keys = key.split("."), value = data[keys.shift()];
            $.each(keys, function () { value = value[this]; });
            return (value === null || value === undefined) ? "" : value;
        });
    };
})(jQuery);