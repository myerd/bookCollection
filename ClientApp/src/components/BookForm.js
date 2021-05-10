import React from 'react'
import '../custom.css'
import { addBook, updBook, deleteBook } from "../services/BookService";

export default class BookForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            Id: null,
            Name: '',
            Author: '',
            Description: ''
        };
        this.inputOnChangeHandler = this.inputOnChangeHandler.bind(this);
    }
    
    updateForm = (e) => {
        if (e) {
            this.setState({
                Id: e.id,
                Name: e.name,
                Author: e.author,
                Description: e.description
            });
        }
        else {
            this.setState( {
                Id: null,
                Name: '',
                Author: '',
                Description: ''
            });
        }
    };
    
    addNewHandler = (e) => {
        e.preventDefault();
        if (this.state.Id === null) {
            const data = {
                Name: this.state.Name,
                Author: this.state.Author,
                Description: this.state.Description
            };
            addBook(data);
            this.updateForm();
        }
        else {
            alert("Save new-button can only be used for non-existing books");
        }
    };
    
    updateHandler = (e) => {
        e.preventDefault();
        if (this.state.Id === null) {
            alert("Save-button can only be used for existing books");
        }
        else {
            updBook(this.state);
            this.updateForm();
        }
    };
    
    deleteHandler = (e) => {
        e.preventDefault();
        if (this.state.Id !== null) {
            deleteBook(this.state.Id);
            this.props.handleDelete(this.state.Id);
            this.updateForm();
        }
        else {
            alert("Need to select book first for deletion");
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
                            name='Name'
                            value={this.state.Name}
                            onChange={this.inputOnChangeHandler}
                        />
                        <p>Author:</p>
                        <input
                            type='text'
                            name='Author'
                            value={this.state.Author}
                            onChange={this.inputOnChangeHandler}
                        />
                        <p>Description</p>
                        <textarea
                            name='Description'
                            value={this.state.Description}
                            onChange={this.inputOnChangeHandler}
                        />
                    </form>
                    <div>
                        <button onClick={this.addNewHandler}>Save new</button>
                        <button onClick={this.updateHandler}>Save</button>
                        <button onClick={this.deleteHandler}>Delete</button>
                    </div>
                </div>
            )
        }
}

