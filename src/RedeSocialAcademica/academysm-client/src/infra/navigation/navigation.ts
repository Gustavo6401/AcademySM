export default function navigateTo(path: string) {
    window.history.pushState({}, '', path)
    window.dispatchEvent(new Event('popstate'))
}