let counters = document.querySelectorAll(".counter");
counters.forEach(counter => {
    counter.innerText = '0';
    let updateCounter = () => {
        let target = +counter.getAttribute("data-target");
        let c = +counter.innerText;
        let increment = target / 250;
        if (c < target) {
            counter.innerText = `${Math.ceil(c + increment)}`
            setTimeout(updateCounter, 20);
        } else {
            counter.innerText = target;
        }
    };
    window.addEventListener("scroll", function () {
        if (window.scrollY >= 1900) {
            updateCounter();
        } else {
            false
        }
    })
});