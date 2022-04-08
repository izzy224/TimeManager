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
import { ChakraProvider } from "@chakra-ui/react";
import theme from "./theme";
import Schedule from "./components/Schedule/Schedule";
import Todos from "./components/Todo/Todos";
import Finances from "./components/Finances/Finances";

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
            <Route path="/todos" element={<Todos />}></Route>
            <Route path="/schedule" element={<Schedule />}></Route>
            <Route path="/finances" element={<Finances />}></Route>
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
