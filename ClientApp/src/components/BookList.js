import React from 'react'
import '../custom.css'
import { getBooks } from '../services/BookService'
import BookForm from "./BookForm";

export default class BookList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            bookList: [],
            isLoading: false,
            error: null
        };
        this.handleDelete = this.handleDelete.bind(this);
        this.handleUpdate = this.handleUpdate.bind(this);
        this.handleAdd = this.handleAdd.bind(this);
    }

    fetchBooks() {
        this.setState(prevState => ({ ...prevState, isLoading: true}));
        getBooks()
            .then(data => this.setState(prevState => ({ ...prevState, bookList: data, isLoading: false})))
            .catch(error => this.setState(prevState => ({ ...prevState, error, isLoading: false})));
    }
    
    componentDidMount() {
        this.fetchBooks();
    }
    
    componentDidUpdate(prevProps) {
        if (this.props.bookList !== prevProps.bookList) {
           this.fetchBooks();
        }
    }

    // Functions to handle state management
    handleDelete(id) {
        this.setState(prevState => ({
            ...prevState,
            bookList: prevState.bookList.filter(book => book.id !== id)
        }));
    }

    handleUpdate(book) {
        const bk = this.state.bookList.findIndex(b => b.id === book.id),
        bookList = [...this.state.bookList];
        bookList[bk] = book;
        this.setState(prevState => ({ ...prevState, bookList }));
    }

    handleAdd(book) {
        const bookList = [...this.state.bookList, book];
        this.setState(prevState => ({ ...prevState, bookList }));
    }
    
    // Function to pass Book-data to form
    click(e) {
        this.bookForm.updateForm(e);
    }
    
    render() {
        const { bookList, isLoading, error} = this.state;

        return (
            <div className="row">
                <div className="bookForm">
                    <BookForm ref={(ip) => (this.bookForm = ip)}
                    handleDelete={this.handleDelete}
                    handleUpdate={this.handleUpdate}
                    handleAdd={this.handleAdd}/>
                </div>
                <div className="bookList">
                    {error ? <p>{error.message}</p> : null}
                    {isLoading ? <p>Loading...</p> : null}
                    <h4>Books in database:</h4>
                    <ul>
                        {bookList.map(book =>
                            <li key={book.id}
                                onClick={() => this.click(book)}>
                                    {book.author}: {book.name}
                            </li>
                        )}
                    </ul>
                </div>
            </div>
        )
    }
};
