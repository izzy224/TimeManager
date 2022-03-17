import {
  Center,
  Flex,
  Box,
  Heading,
  FormControl,
  FormLabel,
  Input,
  Button,
} from "@chakra-ui/react";
import React from "react";

const Login = () => {
  return (
    <>
      <Flex width="full" justifyContent="center" alignItems="center">
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
            <form>
              {/* Username, Password, Email, Name, Surname */}
              <FormControl isRequired>
                <FormLabel>Username</FormLabel>
                <Input />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Email</FormLabel>
                <Input type="email" />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Name</FormLabel>
                <Input type="text" />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Surname</FormLabel>
                <Input type="text" />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Password</FormLabel>
                <Input type="password" />
              </FormControl>
              <FormControl isRequired>
                <FormLabel>Confirm password</FormLabel>
                <Input type="password" />
              </FormControl>
              <Button width="full" mt={4} type="submit">
                Register
              </Button>
            </form>
          </Box>
        </Box>
      </Flex>
    </>
  );
};

export default Login;
