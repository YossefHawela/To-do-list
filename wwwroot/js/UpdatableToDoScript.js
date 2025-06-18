
function updateAllTimers() {
    const elements = document.querySelectorAll('.estimated-time');

    elements.forEach(el => {
        const deadline = new Date(el.dataset.deadline);
        const now = new Date();
        const diff = deadline - now;

        if (diff <= 0) {
            el.textContent = "Estimated time: Time's up!";
            return;
        }

        const days = Math.floor(diff / (1000 * 60 * 60 * 24));
        const hours = Math.floor((diff / (1000 * 60 * 60)) % 24);
        const minutes = Math.floor((diff / (1000 * 60)) % 60);
        const seconds = Math.floor((diff / 1000) % 60);

        el.textContent =
            `Estimated time: ${days} Days, ${hours.toString().padStart(2, '0')}:${minutes.toString().padStart(2, '0')}:${seconds.toString().padStart(2, '0')}`;
    });
}

updateAllTimers();
setInterval(updateAllTimers, 1000);
