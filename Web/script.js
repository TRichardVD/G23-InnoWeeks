// script.js

function login() {
    // Récupère les valeurs des champs de texte
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;

    // Pour simplifier, nous allons supposer que le login est toujours correct
    // Dans une vraie application, il faudrait vérifier le login côté serveur

    if (username && password) {
        // Stocke le nom d'utilisateur dans le stockage local du navigateur
        localStorage.setItem('username', username);

        // Redirige vers le tableau de bord
        window.location.href = 'dashboard.html';
    } else {
        alert('Veuillez entrer un nom d\'utilisateur et un mot de passe.');
    }
}

// Cette fonction est appelée lorsque le tableau de bord est chargé
function loadDashboard() {
    // Récupère le nom d'utilisateur du stockage local
    const username = localStorage.getItem('username');

    if (username) {
        // Affiche le nom d'utilisateur dans la page
        document.getElementById('user-name').textContent = username;
    } else {
        // Si aucun nom d'utilisateur n'est trouvé, redirige vers la page de connexion
        window.location.href = 'index.html';
    }
}

// Si la page est "dashboard.html", appelle la fonction loadDashboard
if (window.location.pathname.includes('dashboard.html')) {
    loadDashboard();
}
