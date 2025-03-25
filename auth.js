// Authentication state management
let isAuthenticated = false;

// Check authentication status on page load
document.addEventListener('DOMContentLoaded', () => {
    const token = localStorage.getItem('authToken');
    isAuthenticated = !!token;
    
    // Redirect to login if not authenticated and trying to access protected pages
    if (!isAuthenticated && !window.location.pathname.includes('login.html') && !window.location.pathname.includes('signup.html')) {
        window.location.href = '/Pages/login.html';
    }
    
    // Redirect to dashboard if authenticated and trying to access auth pages
    if (isAuthenticated && (window.location.pathname.includes('login.html') || window.location.pathname.includes('signup.html'))) {
        window.location.href = '/Pages/dashboard.html';
    }
});

// Login form handler
const loginForm = document.getElementById('loginForm');
if (loginForm) {
    loginForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const email = document.getElementById('loginEmail').value;
        const password = document.getElementById('loginPassword').value;

        try {
            const response = await fetch('/api/auth/login', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ email, password }),
            });

            if (response.ok) {
                const data = await response.json();
                localStorage.setItem('authToken', data.token);
                window.location.href = '/Pages/dashboard.html';
            } else {
                const errorDiv = document.getElementById('loginError');
                errorDiv.textContent = 'Invalid email or password';
                errorDiv.style.display = 'block';
            }
        } catch (error) {
            console.error('Login error:', error);
        }
    });
}

// Signup form handler
const signupForm = document.getElementById('signupForm');
if (signupForm) {
    signupForm.addEventListener('submit', async (e) => {
        e.preventDefault();
        const name = document.getElementById('signupName').value;
        const email = document.getElementById('signupEmail').value;
        const password = document.getElementById('signupPassword').value;
        const confirmPassword = document.getElementById('signupConfirmPassword').value;

        if (password !== confirmPassword) {
            alert('Passwords do not match');
            return;
        }

        try {
            const response = await fetch('/api/auth/signup', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify({ name, email, password }),
            });

            if (response.ok) {
                window.location.href = '/Pages/login.html';
            } else {
                alert('Signup failed. Please try again.');
            }
        } catch (error) {
            console.error('Signup error:', error);
        }
    });
}

// Logout handler
const logoutBtn = document.getElementById('logoutBtn');
if (logoutBtn) {
    logoutBtn.addEventListener('click', () => {
        localStorage.removeItem('authToken');
        window.location.href = '/Pages/login.html';
    });
}

export async function login(email, password) {
    const errorElement = document.getElementById('loginError');
    const emailInput = document.getElementById('loginEmail');
    const passwordInput = document.getElementById('loginPassword');
    
    // Clear previous errors
    errorElement.style.display = 'none';
    emailInput.classList.remove('error');
    passwordInput.classList.remove('error');
    
    try {
        // Simple client-side validation
        if (!email) {
            throw new Error('Please enter your email');
        }
        if (!password) {
            throw new Error('Please enter your password');
        }

        // Simulate API call (replace with actual fetch to your backend)
        const response = await fetch(`${API_BASE_URL}/auth/login`, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
            },
            body: JSON.stringify({ email, password })
        });

        if (response.ok) {
            const data = await response.json();
            
            // Store authentication data
            localStorage.setItem('authToken', data.token);
            localStorage.setItem('user', JSON.stringify(data.user));
            
            // Redirect to dashboard
            window.location.hash = '#dashboard';
            return true;
        } else {
            const errorData = await response.json();
            throw new Error(errorData.message || 'Invalid email or password');
        }
    } catch (error) {
        // Show error to user
        errorElement.textContent = error.message;
        errorElement.style.display = 'block';
        
        // Highlight problematic fields
        if (error.message.toLowerCase().includes('email')) {
            emailInput.classList.add('error');
            emailInput.focus();
        } else if (error.message.toLowerCase().includes('password')) {
            passwordInput.classList.add('error');
            passwordInput.focus();
        }
        
        return false;
    }
}

export function setupLogin() {
    const form = document.getElementById('loginForm');
    if (form) {
        form.addEventListener('submit', async (e) => {
            e.preventDefault();
            const email = document.getElementById('loginEmail').value;
            const password = document.getElementById('loginPassword').value;
            await login(email, password);
        });
    }
}

// Temporary mock API - PUT THIS AT THE TOP OF auth.js
async function mockAuthApi(email, password) {
    // Simulate network delay
    await new Promise(resolve => setTimeout(resolve, 500));
    
    // Test credentials (change these to match your test user)
    const testUser = {
        email: "test@example.com",
        password: "password123"
    };
    
    if (email === testUser.email && password === testUser.password) {
        return {
            ok: true,
            json: async () => ({
                token: "mock-jwt-token",
                user: {
                    id: 1,
                    name: "Test User",
                    email: email
                }
            })
        };
    } else {
        return {
            ok: false,
            json: async () => ({
                message: "Invalid email or password"
            })
        };
    }
}

// THEN MODIFY YOUR EXISTING login() FUNCTION LIKE THIS:
export async function login(email, password) {
    const errorElement = document.getElementById('loginError');
    // ... (keep existing error clearing code)
    
    try {
        // ... (keep existing validation)
        
        // REPLACE the fetch call with this mock version:
        const response = await mockAuthApi(email, password);
        
        if (response.ok) {
            // ... (keep existing success handling)
        } else {
            // ... (keep existing error handling)
        }
    } catch (error) {
        // ... (keep existing catch block)
    }
}