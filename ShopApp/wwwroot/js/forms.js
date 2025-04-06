console.log("Forms loaded");
// Allow comma as decimal separator for numeric validation
$.validator.methods.number = function (value, element) {
    return this.optional(element) || /^-?\d+(,\d+)?$/.test(value);
};

$.validator.methods.range = function (value, element, param) {
    var globalizedValue = value.replace(",", ".");
    return this.optional(element) ||
        (globalizedValue >= param[0] && globalizedValue <= param[1]);
};

// Multiple dropdown
$(document).ready(function () {

    // On page load, check for any pre-selected checkboxes
    var selected = [];
    $('.dropdown-menu input[type="checkbox"]:checked').each(function () {
        selected.push($(this).parent().text().trim());
    });
    if (selected.length > 0) {
        $('.selected-items').text(selected.join(', '));
    } else {
        $('.selected-items').text('Select Categories');
    }

    // Toggle dropdown menu on click
    $('.dropdown-toggle').click(function (e) {
        e.stopPropagation();
        $(this).next('.dropdown-menu').toggle();
    });

    // Update selected text when a checkbox changes
    $('.dropdown-menu input[type="checkbox"]').change(function () {
        var selected = [];
        $('.dropdown-menu input[type="checkbox"]:checked').each(function () {
            selected.push($(this).parent().text().trim());
        });
        if (selected.length > 0) {
            $('.selected-items').text(selected.join(', '));
        } else {
            $('.selected-items').text('Select Categories');
        }
    });

    // Hide the dropdown if clicking outside
    $(document).click(function (e) {
        if (!$(e.target).closest('.multi-select-dropdown').length) {
            $('.dropdown-menu').hide();
        }
    });
});