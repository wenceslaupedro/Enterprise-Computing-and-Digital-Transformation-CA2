import { checkAuth, logout } from './auth.js';

const routes = {
    '#login': { file: 'pages/login.html', auth: false },
    '#signup': { file: 'pages/signup.html', auth: false },
    '#dashboard': { file: 'pages/dashboard.html', auth: true },
    '': { redirect: '#login' }
};

async function loadRoute() {
    const hash = window.location.hash || '#login';
    const route = routes[hash] || routes[''];
    
    if (route.redirect) {
        window.location.hash = route.redirect;
        return;
    }
    
    // Check authentication
    const isAuthenticated = await checkAuth();
    
    if (route.auth && !isAuthenticated) {
        window.location.hash = '#login';
        return;
    }
    
    if (!route.auth && isAuthenticated) {
        window.location.hash = '#dashboard';
        return;
    }
    
    // Load the page
    try {
        const response = await fetch(route.file);
        const html = await response.text();
        document.getElementById('app').innerHTML = html;
        
        // Load page-specific JS
        if (hash === '#login') {
            import('./auth.js').then(module => module.setupLogin());
        } else if (hash === '#signup') {
            import('./auth.js').then(module => module.setupSignup());
        } else if (hash === '#dashboard') {
            import('./calendar.js').then(module => module.initCalendar());
        }
    } catch (error) {
        console.error('Error loading page:', error);
    }
}

// Handle navigation
window.addEventListener('hashchange', loadRoute);
window.addEventListener('DOMContentLoaded', loadRoute);