import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true };
    }

    componentDidMount() {
        this.getAllArticle();
    }

    static renderAllArticle(articleList) { 
        return (
            <div>
                <header className="masthead" style={{ backgroundImage: "url('/home-bg.jpg')" }}>
                    <div className="container position-relative px-4 px-lg-5">
                        <div className="row gx-4 gx-lg-5 justify-content-center">
                            <div className="col-md-10 col-lg-8 col-xl-7">
                                <div className="site-heading">
                                    <h1>BlogMaster</h1>
                                    <span className="subheading">A Dynamic Blog</span>
                                </div>
                            </div>
                        </div>
                    </div>
                </header>

                <div className="container px-4 px-lg-5">
                    <div className="row gx-4 gx-lg-5 justify-content-center">
                        <div className="col-md-10 col-lg-8 col-xl-7">
                            {articleList.map(article =>

                                <div className="post-preview" key={article.articleId}>
                                    <a href={`~/Blog/Post/${article.articleId}`}>
                                        <h2 className="post-title">{article.header}</h2>
                                        <h3 className="post-subtitle">{article.subHeader}</h3>
                                    </a>
                                    <p className="post-meta">
                                        Posted by
                                        <a href={`~/Blog/About/${article.username}`}>{article.username}</a>
                                        {article.creationDate}
                                    </p>
                                </div>
                            )} 
                        </div>
                    </div>
                </div>
            </div>
        );
    }

    render() {
        let contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : Home.renderAllArticle(this.state.articleList);

        return (
            <div>
                {contents}
            </div>
        );
    }

    async getAllArticle() {
        const response = await fetch('https://localhost:7296/api/Article/GetArticleInformationForHomePage'); 
        const data = await response.json();
        this.setState({ articleList: data, loading: false });
    }
}
