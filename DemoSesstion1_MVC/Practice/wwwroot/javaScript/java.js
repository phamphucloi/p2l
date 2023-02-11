var body = document.querySelector('body');
var button = document.querySelector('button');

function change() {
    button.addEventListener('click', () => {
        body.classList.toggle('change');
    })
}