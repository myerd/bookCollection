import React from 'react'
import '../custom.css'
import { addBook, updBook, deleteBook } from "../services/BookService";

export default class BookForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            id: null,
            name: '',
            author: '',
            description: ''
        };
        this.inputOnChangeHandler = this.inputOnChangeHandler.bind(this);
    }

    updateForm = (e) => {
        if (e) {
            this.setState({
                id: e.id,
                name: e.name,
                author: e.author,
                description: e.description
            });
        }
        else {
            this.setState( {
                id: null,
                name: '',
                author: '',
                description: ''
            });
        }
    };

    addNewHandler = async (e) => {
        e.preventDefault();
        const data = {
            name: this.state.name,
            author: this.state.author,
            description: this.state.description
        };
        const book = await addBook(data);
        this.props.handleAdd(book);
        this.updateForm();
    };

    updateHandler = async (e) => {
        e.preventDefault();
        const book = await updBook(this.state);
        this.props.handleUpdate(book);
        this.updateForm();
    };

    deleteHandler = async (e) => {
        e.preventDefault();
        if (this.state.id !== null) {
            const res = await deleteBook(this.state.id);
            this.props.handleDelete(res);
            this.updateForm();
        }
    };

    inputOnChangeHandler(e) {
        const target = e.target;
        const value = target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    render()
    {
        return (
            <div className="bookForm">
                <h4>Book details:</h4>
                <form>
                    <p>Name:</p>
                    <input
                        type='text'
                        name='name'
                        value={this.state.name}
                        onChange={this.inputOnChangeHandler}
                        required='required'
                    />
                    <p>Author:</p>
                    <input
                        type='text'
                        name='author'
                        value={this.state.author}
                        onChange={this.inputOnChangeHandler}
                        required='required'
                    />
                    <p>Description</p>
                    <textarea
                        name='description'
                        value={this.state.description}
                        onChange={this.inputOnChangeHandler}
                    />
                </form>
                <div>
                    <button onClick={this.addNewHandler}
                            disabled={!this.state.name || !this.state.author || !!this.state.id}>
                        Save new</button>
                    <button onClick={this.updateHandler} disabled={!this.state.id}>Save</button>
                    <button onClick={this.deleteHandler} disabled={!this.state.id}>Delete</button>
                </div>
            </div>
        )
    }
}

