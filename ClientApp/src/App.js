import React, { Component } from 'react';
import BookList from './components/BookList'

import './custom.css'

export default class App extends Component {
  static displayName = App.name;

  render () {
    return (
        <div className="App">
           <div className="header">
           </div>    
          <BookList/>
        </div>
    );
  }
}
