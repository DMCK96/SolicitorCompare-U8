export default function initScrollTo() {
  const links = document.getElementsByClassName('anchor-link');

  if (links.count === 0) {
    return;
  }

  Array.from(links).forEach(each => {
    each.addEventListener('click', (e) => scrollTo(e));
  });
};

const scrollTo = function scrollAnchors(e) {
  const distanceToTop = el => Math.floor(el.getBoundingClientRect().top);

  e.preventDefault();

  const targetID = e.target.getAttribute('href');
  const targetAnchor = document.querySelector(targetID);

  if (!targetAnchor) return;

  let originalTop = distanceToTop(targetAnchor);
  originalTop = originalTop - 200;

  window.scrollBy({ top: originalTop, left: 0, behavior: 'smooth' });

  const checkIfDone = setInterval (function () {
    const atBottom = window.innerHeight + window.pageYOffset >= document.body.offsetHeight - 2;
    if (distanceToTop(targetAnchor) === 0 || atBottom) {
      targetAnchor.tabIndex = '-1';
      targetAnchor.focus();
      window.history.pushState('', '', targetID);
      clearInterval(checkIfDone);
    }
  }, 100);
};
