import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter } from "react-router-dom";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { Route, Routes } from "react-router-dom";
import Navbar from "./components/Navbar";
import Register from "./components/Register";
import Login from "./components/Login";
import Home from "./components/Home";
import { ChakraProvider } from "@chakra-ui/react";
import theme from "./theme";
import Schedule from "./components/Schedule/Schedule";
import Todos from "./components/Todo/Todos";

ReactDOM.render(
  // Changed React.StrictMode to React.Fragment
  <React.Fragment>
    <ChakraProvider theme={theme}>
        <BrowserRouter>
          <Navbar />
          <div>
            <Routes>
              <Route path="/" element={<App />}></Route>
              <Route path="/register" element={<Register />}></Route>
              <Route path="/login" element={<Login />}></Route>
              <Route path="/home" element={<Home />}></Route>
              <Route path="/todos" element={<Todos />}></Route>
              <Route path="/schedule" element={<Schedule />}></Route>
            </Routes>
          </div>
        </BrowserRouter>
    </ChakraProvider>
  </React.Fragment>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
