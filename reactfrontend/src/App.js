import {
  Flex,
  Box,
  Text,
  Center,
  Heading,
  Button,
  VStack,
  StackDivider,
} from "@chakra-ui/react";
import React from "react";
import { useNavigate } from "react-router-dom";
const App = () => {
  const nav = useNavigate();
  const handleRegisterButton = (event) => {
    nav("/register");
    event.preventDefault();
  };
  const handleLoginButton = (event) => {
    nav("/login");
    event.preventDefault();
  };

  return (
    <>
      <Flex>
        <Box boxShadow="dark-lg" px="10" width="35vw" height="94vh">
          <Box fontFamily="furura-pt, monospace" py="20" className="Header">
            <Heading
              fontFamily="futura-pt, sans-serif"
              fontWeight="700"
              fontSize="6xl"
              textAlign="center"
            >
              TempName
            </Heading>
            <Text fontSize="2xl" textAlign="center">
              A resource manager
            </Text>
          </Box>
          <Center>
            <Box fontSize="xl" fontFamily="montserrat, monospace">
              <Text py="2">Quick and efficient time planning</Text>
              <Text py="2">Management of financial resources</Text>
              <Text py="2">Audit calculation in visual form</Text>
              {/*Graphs for seeing money waste and profit */}
              <Text py="2">Easy schedule creation</Text>
              <Text py="2">Clean design for a great UX</Text>
            </Box>
          </Center>
        </Box>
        <Box py="15%" width="65vw" height="94vh">
          <Center>
            <VStack textAlign="center" spacing={4} align="stretch">
              <Text px="5" fontSize="2xl">
                Just a few clicks away from resource awareness
              </Text>
              <Button colorScheme="messenger" onClick={handleRegisterButton}>
                Register
              </Button>

              <Text px="5" fontSize="2xl">
                Already a member?
              </Text>
              <Button colorScheme="messenger" onClick={handleLoginButton}>
                Login
              </Button>
            </VStack>
          </Center>
        </Box>
        {/* Resource management is the key */}
      </Flex>
    </>
  );
};

export default App;
