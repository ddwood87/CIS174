
jQuery.validator.addMethod("points",
    function (value, element, param) {
        if (value == 0) { return false; }
        if (value >= 1 && value <= 10) { return true; }
        else { return false; }
    }
);
jQuery.validator.unobtrusive.adapters.addBool("points");

jQuery.validator.addMethod("sprintId",
    function (value, element, param) {
        if (value == -1 || (value >= 1 && value <= 10)) { return true; }
        else { return false; }
    }
);
jQuery.validator.unobtrusive.adapters.addBool("sprintId");