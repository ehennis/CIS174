$(function () {

    jQuery.validator.addMethod("moviefirstname",
        function (value, element, param) {
            if (value == '') return false;
            if (value == 'EvanH') return false;
            return true;
        }, jQuery.validator.format('Client Side Validation'));

    jQuery.validator.unobtrusive.adapters.addSingleVale("moviefirstname","name");

}(jQuery));
