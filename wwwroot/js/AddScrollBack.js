document.querySelector("form").addEventListener("submit", () => {
    localStorage.setItem("scrollY", window.scrollY);
});


window.addEventListener("load", () => {
    const y = localStorage.getItem("scrollY");
    if (y) window.scrollTo(0, parseInt(y));
});