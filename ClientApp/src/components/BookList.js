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
    }

    componentDidMount() {
        this.setState({ isLoading: true});
        getBooks()
            .then(data =>
                this.setState({bookList: data, isLoading: false}))
            .catch(error => this.setState({error, isLoading: false}));
    }
    
    componentDidUpdate(prevProps) {
        if (this.props.bookList !== prevProps.bookList) {
            getBooks()
                .then(data =>
                this.setState( {bookList: data}))
                .catch(error => this.setState({error}));
        }
    }

    handleDelete(id) {
        this.setState(prevState => ({
            bookList: prevState.bookList.filter(book => book.Id !== id)}));
    }


    click(e) {
        this.bookForm.updateForm(e);
    }
    
    render() {
        const { bookList, isLoading, error} = this.state;

        if (error) {
            return <p>{error.message}</p>
        }

        if (isLoading) {
            return <p>Loading...</p>
        }

        return (
            <div className="row">
                <div className="bookForm">
                    <BookForm ref={(ip) => (this.bookForm = ip)}
                    handleDelete={this.handleDelete}/>
                </div>
                <div className="bookList">
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
