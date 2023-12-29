import React, { useState } from 'react';
import { Container, Navbar, Nav, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';

const NavMenu = () => {
    const [collapsed, setCollapsed] = useState(true);

    const toggleNavbar = () => setCollapsed(!collapsed);

    return (
        <header>
            <Navbar className="navbar navbar-expand-lg navbar-light" id="mainNav">
                <Container>
                    <Link className="navbar-brand" to="/">BlogMaster</Link>
                    <button className="navbar-toggler" type="button" onClick={toggleNavbar}>
                        Menu
                        <i className="fas fa-bars"></i>
                    </button>
                    <div className={`collapse navbar-collapse ${collapsed ? '' : 'show'}`} id="navbarResponsive">
                        <Nav className="navbar-nav ms-auto py-4 py-lg-0">
                            <NavItem><NavLink tag={Link} to="/" className="nav-link px-lg-3 py-3 py-lg-4">Home</NavLink></NavItem>
                            <NavItem><NavLink tag={Link} to="/Blog/About" className="nav-link px-lg-3 py-3 py-lg-4">About</NavLink></NavItem>
                            <NavItem><NavLink tag={Link} to="/post.html" className="nav-link px-lg-3 py-3 py-lg-4">Sample Post</NavLink></NavItem>
                            <NavItem><NavLink tag={Link} to="/contact.html" className="nav-link px-lg-3 py-3 py-lg-4">Contact</NavLink></NavItem>
                        </Nav>
                    </div>
                </Container>
            </Navbar> 
        </header>
    );
};

export default NavMenu;
