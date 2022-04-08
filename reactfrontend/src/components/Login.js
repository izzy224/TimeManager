import React, { useState } from "react";
import { Navigate, Link } from "react-router-dom";
import {
  Center,
  Flex,
  Box,
  Heading,
  FormControl,
  FormLabel,
  Input,
  Button,
  Link as ChakraLink,
} from "@chakra-ui/react";
import ErrorMessage from "./ErrorMessage";
const Login = () => {
  const [login, setLogin] = useState("");
  const [password, setPassword] = useState("");
  const [success, setSuccess] = useState(false);
  const [message, setMessage] = useState("");

  const handleSubmit = (event) => {
    fetch("/api/login", {
      headers: { "Content-type": "application/json" },
      credentials: "include",
      method: "POST",
      body: JSON.stringify({ Username: login, Password: password }),
    })
      .then((response) => response.json())
      .then((data) => {
        console.log(data);

        if (data?.message == "success") {
          window.sessionStorage.setItem("token", "Bearer " + data?.jwtToken);
          setSuccess(true);
        } else {
          setMessage(data?.message);
        }
      });

    event.preventDefault();
  };
  if (success) {
    return <Navigate to="/todos" />;
  }
  return (
    <>
      <Flex mt="5" width="full" justifyContent="center" alignItems="center">
        <Box
          p="8"
          maxWidth="1000px"
          borderWidth="1"
          borderRadius="12"
          boxShadow="lg"
        >
          <Box textAlign="center">
            <Heading>Login</Heading>
            <Box my="4" textAlign="left"></Box>
            <form onSubmit={handleSubmit}>
              <FormControl isRequired>
                <FormLabel>Username</FormLabel>
                <Input
                  type="text"
                  onChange={(event) => setLogin(event.currentTarget.value)}
                />
              </FormControl>

              <FormControl isRequired>
                <FormLabel>Password</FormLabel>
                <Input
                  type="password"
                  onChange={(event) => setPassword(event.currentTarget.value)}
                />
              </FormControl>
              <Button width="full" mt={4} type="submit">
                Login
              </Button>
            </form>
          </Box>
          <Center>
            <ChakraLink as={Link} to="/register">
              Don't have an account?
            </ChakraLink>
          </Center>
          <Center>
            {message !== "" ? <ErrorMessage message={message} /> : ""}
          </Center>
        </Box>
      </Flex>
    </>
  );
};

export default Login;
