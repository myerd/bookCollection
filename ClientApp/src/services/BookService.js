// Functions to handle backend API calls
export async function getBooks() {
    const response = await fetch('api/book');
    return await response.json();
}

export async function addBook(data) {
    const response = await fetch( 'api/book', {
        method: 'POST',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)
    });
    return await response.json();
}

export async function updBook(data) {
    const response = await fetch ('api/book', {
        method: 'PUT',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)
    });
    return await response.json();
}

export async function deleteBook(data) {
    const response = await fetch('api/book', {
        method: 'DELETE',
        headers: {'Content-Type': 'application/json'},
        body: JSON.stringify(data)
    });
    return await response.json();
}
