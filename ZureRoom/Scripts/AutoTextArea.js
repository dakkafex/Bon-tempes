$(document).ready(function () {
    $('textarea').each(function () {
        this.setAttribute('style', 'height:' + (this.scrollHeight + 5) + 'px;overflow-y:hidden;');
    }).on('input', function () {
        this.style.height = 'auto';
        this.style.height = (this.scrollHeight) + 'px';
    });
});