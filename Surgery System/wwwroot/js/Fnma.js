window.addEventListener('load', () => {
    const formElement = document.querySelector('.register-box form');
    if (formElement) {
        formElement.scrollIntoView({ behavior: 'smooth', block: 'start' });
    }
});