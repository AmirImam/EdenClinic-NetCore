import focusTrap from 'focus-trap';
export class BlazoredModal {
    constructor() {
        this._options = { escapeDeactivates: false };
        this._traps = [];
    }
    activateScrollLock() {
        const scrollY = window.scrollY;
        const body = document.body;
        body.style.width = `${body.offsetWidth}px`;
        body.style.position = 'fixed';
        body.style.top = `-${scrollY}px`;
    }
    activateFocusTrap(element, id) {
        const trap = focusTrap(element, this._options);
        try {
            trap.activate();
            this._traps.push({ id, focusTrap: trap });
        }
        catch (e) {
            if (e instanceof Error && e.message === 'Your focus-trap needs to have at least one focusable element') {
                console.log('Focus trap not activated - No focusable elements found.');
            }
        }
    }
    deactivateFocusTrap(id) {
        const trap = this._traps.find(i => i.id === id);
        const scrollY = document.body.style.top;
        document.body.style.position = '';
        document.body.style.top = '';
        document.body.style.width = '';
        window.scrollTo(0, parseInt(scrollY || '0') * -1);
        if (trap) {
            trap.focusTrap.deactivate();
            const index = this._traps.indexOf(trap);
            if (index > -1) {
                this._traps.splice(index, 1);
            }
        }
    }
}
window.BlazoredModal = new BlazoredModal();
